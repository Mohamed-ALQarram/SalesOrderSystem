using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Customer_Classes
{
    public class CustomerModelBinder : IModelBinder
    {
        private readonly IModelBinderFactory _binderFactory;
        private readonly IModelMetadataProvider _metadataProvider;

        public CustomerModelBinder(IModelBinderFactory binderFactory,
                                   IModelMetadataProvider metadataProvider)
        {
            _binderFactory = binderFactory;
            _metadataProvider = metadataProvider;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var typeValue = bindingContext.ValueProvider.GetValue("Type").FirstValue;

            if (string.IsNullOrWhiteSpace(typeValue))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            Type concreteType = typeValue switch
            {
                "Person" => typeof(Person),
                "Company" => typeof(Company),
                _ => typeof(Person)
            };

            if (concreteType == null)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            // Create a new metadata for the concrete type
            var concreteMetadata = _metadataProvider.GetMetadataForType(concreteType);

            // Create a binder for the concrete type
            var concreteBinder = _binderFactory.CreateBinder(new ModelBinderFactoryContext
            {
                Metadata = concreteMetadata,
                CacheToken = concreteType
            });

            // Create a new binding context for the concrete type
            var newBindingContext = DefaultModelBindingContext.CreateBindingContext(
                bindingContext.ActionContext,
                bindingContext.ValueProvider,
                concreteMetadata,
                bindingInfo: null,
                modelName: bindingContext.ModelName
            );

            // Important: we manually set the model instance so binder populates it
            newBindingContext.Model = Activator.CreateInstance(concreteType);

            await concreteBinder.BindModelAsync(newBindingContext);

            if (newBindingContext.Result.IsModelSet)
            {
                bindingContext.Result = ModelBindingResult.Success(newBindingContext.Result.Model);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
        }
    }

    public class CustomerModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Customer))
            {
                return new CustomerModelBinder(
                    (IModelBinderFactory)context.Services.GetService(typeof(IModelBinderFactory))!,
                    (IModelMetadataProvider)context.Services.GetService(typeof(IModelMetadataProvider))!
                );
            }
            return null!;
        }
    }
}

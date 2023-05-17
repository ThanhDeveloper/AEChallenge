using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Globalization;
using System.Text.Json;

namespace AEPortal.Common.Extentions
{
    public static class JsonSerializationExtensions
    {
        private static readonly SnakeCaseNamingStrategy _snakeCaseNamingStrategy
            = new SnakeCaseNamingStrategy();

        private static readonly JsonSerializerSettings _snakeCaseSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = _snakeCaseNamingStrategy
            }
        };

        public static string ToSnakeCase<T>(this T instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(paramName: nameof(instance));
            }

            return JsonConvert.SerializeObject(instance, _snakeCaseSettings);
        }

        public static string ToSnakeCase(this string @string)
        {
            if (@string == null)
            {
                throw new ArgumentNullException(paramName: nameof(@string));
            }

            return _snakeCaseNamingStrategy.GetPropertyName(@string, false);
        }
    }
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToSnakeCase();
    }

    public class SnakeCaseSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null) return;
            if (schema.Properties.Count == 0) return;

            var keys = schema.Properties.Keys;
            var newProperties = new Dictionary<string, OpenApiSchema>();
            foreach (var key in keys)
            {
                newProperties[key.ToSnakeCase()] = schema.Properties[key];
            }

            schema.Properties = newProperties;
        }
    }
    public class SnakecasingParameOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();
            else
            {
                foreach (var item in operation.Parameters)
                {
                    item.Name = item.Name.ToSnakeCase();
                }
            }
        }
    }
    public class SnakeCaseQueryValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var valueProvider = new SnakeCaseQueryValueProvider(
                BindingSource.Query,
                context.ActionContext.HttpContext.Request.Query,
                CultureInfo.CurrentCulture);

            context.ValueProviders.Add(valueProvider);

            return Task.CompletedTask;
        }
    }
    public class SnakeCaseQueryValueProvider : QueryStringValueProvider, Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
    {
        public SnakeCaseQueryValueProvider(
            BindingSource bindingSource,
            IQueryCollection values,
            CultureInfo culture)
            : base(bindingSource, values, culture)
        {
        }

        public override bool ContainsPrefix(string prefix)
        {
            return base.ContainsPrefix(prefix.ToSnakeCase());
        }

        public override ValueProviderResult GetValue(string key)
        {
            return base.GetValue(key.ToSnakeCase());
        }
    }
}

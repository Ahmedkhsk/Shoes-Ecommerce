namespace Shoes_Ecommerce.Helpers.Localization
{
    public static class EntityHelper
    {
        public static IEnumerable<object> FilterEntitiesByLanguage<T>(IEnumerable<T> entities, string lan, string enPropertyName = "NameEn", string arPropertyName = "NameAr")
        {
            return entities.Select(entity =>
            {
                var entityType = entity.GetType();
                var properties = entityType.GetProperties();
                var result = new Dictionary<string, object>();

                foreach (var property in properties)
                {
                    if (property.Name == enPropertyName && lan == "en")
                    {
                        result["Name"] = property.GetValue(entity);
                    }
                    else if (property.Name == arPropertyName && lan == "ar")
                    {
                        result["Name"] = property.GetValue(entity);
                    }
                    else if (property.Name != enPropertyName && property.Name != arPropertyName)
                    {
                        result[property.Name] = property.GetValue(entity);
                    }
                }

                return result;
            });
        }
    }
}

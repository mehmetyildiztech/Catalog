namespace Web
{
    public static class Endpoints
    {
        public static class Merchants
        {
            public const string Base = "merchants";
            public const string ById = "{id:guid}";
            public const string Activate = "{id:guid}/activate";
            public const string Deactivate = "{id:guid}/deactivate";
        }

        public static class Catalogs
        {
            public const string Base = "merchants/{merchantId:guid}/catalogs";
            public const string ById = "{id:guid}";
            public const string Activate = "{id:guid}/activate";
            public const string Deactivate = "{id:guid}/deactivate";
        }

        public static class CatalogItems
        {
            public const string Base = "catalogs/{catalogId:guid}/items";
            public const string ById = "{id:guid}";
            public const string Activate = "{id:guid}/activate";
            public const string Deactivate = "{id:guid}/deactivate";
        }
    }
}

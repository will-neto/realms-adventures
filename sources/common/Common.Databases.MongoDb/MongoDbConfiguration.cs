using Common.DomainDrivenDesign.DomainObjects;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace Common.Databases.MongoDb;

public static class MongoDbConfiguration
{
    public static void Configure()
    {
        RegisterConventions();
        RegisterSerializer();
        MappingClass();
    }

    private static void RegisterSerializer()
    {
        BsonSerializer.UseNullIdChecker = true;
        BsonSerializer.UseZeroIdChecker = true;
        BsonSerializer.RegisterIdGenerator(typeof(Guid), CombGuidGenerator.Instance);

        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        BsonSerializer.RegisterSerializer(typeof(DateTimeOffset), new DateTimeSerializer(DateTimeKind.Utc, BsonType.DateTime));
        BsonSerializer.RegisterSerializer(typeof(DateTime), new DateTimeSerializer(DateTimeKind.Utc, BsonType.DateTime));
        BsonSerializer.RegisterSerializer(typeof(bool), new BooleanSerializer(BsonType.Boolean));
        BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Decimal128));
        BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));
        //BsonSerializer.RegisterSerializer(new EnumSerializer<MyAwesomeEnum>(BsonType.String));
    }

    private static void MappingClass() => BsonClassMap.RegisterClassMap<Entity>(cm =>
    {
        cm.AutoMap();
    });

    private static void RegisterConventions()
    {
        var pack = new ConventionPack
        {
            new IgnoreExtraElementsConvention(true),
            //new IgnoreIfDefaultConvention(true),
            new CamelCaseElementNameConvention()
        };

        ConventionRegistry.Register("My solution convention", pack, t => true);
    }
}
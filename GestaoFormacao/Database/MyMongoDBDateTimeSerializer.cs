﻿using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GestaoFormacao.Database
{
    public class MyMongoDBDateTimeSerializer: DateTimeSerializer 
    {
        //  MongoDB returns datetime as DateTimeKind.Utc, which can't be used in our timezone conversion logic
        //  We overwrite it to be DateTimeKind.Unspecified
        public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var obj = base.Deserialize(context, args);
            return new DateTime(obj.Ticks, DateTimeKind.Unspecified);
        }

        //  MongoDB stores all DateTime as Utc, any DateTime value DateTimeKind is not DateTimeKind.Utc, will be converted to Utc first
        //  We overwrite it to be DateTimeKind.Utc, becasue we want to preserve the raw value
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
        {
            var utcValue = new DateTime(value.Ticks, DateTimeKind.Utc);
            base.Serialize(context, args, utcValue);
        }
    }
}

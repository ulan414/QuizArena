using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;

public class DatabaseAccess : MonoBehaviour
{
    MongoClient client = new MongoClient("mongodb+srv://qulpynaimm:10Aruzhan2002@cluster0.4gjcypy.mongodb.net/?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;
    // Start is called before the first frame update
    void Start()
    {
        database = client.GetDatabase("Quiz_Arena");
        collection = database.GetCollection<BsonDocument>("Quiz_Arena");

        //test
        var document = new BsonDocument{ { "username", 100} };
        collection.InsertOne(document);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

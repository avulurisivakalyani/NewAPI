using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace GWAPI.Models
{
   public class AggregateHC
    {
       
            public Data Data { get; set; }
            public string Duration { get; set; }
            public string Status { get; set; }
            public List<object> Tags { get; set; }
        }

        public class AzureStorageAccess1
        {
            public Data Data { get; set; }
            public string description { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
            public List<object> tags { get; set; }
        }

        public class CosmosDBConnection1
        {
            public Data data { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
            public List<object> tags { get; set; }
        }

        public class CosmosDBConnectionStringNull
        {
            public Data data { get; set; }
            public string description { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
            public List<object> tags { get; set; }
        }

        public class CosmosDBConnectionStringRegex
        {
            public Data data { get; set; }
            public string description { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
            public List<object> tags { get; set; }
        }

        public class CosmosdbIndex
        {
            public string healthStatus { get; set; }
        }

        public class Data
        {
            [JsonProperty("cosmosdb-index")]
            public CosmosdbIndex CosmosdbIndex { get; set; }
        }

        public class DbHealthCheck
        {
            public Data data { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
            public List<object> tags { get; set; }
        }

        public class Entries
        {
            [JsonProperty("db health check")]
            public DbHealthCheck DbHealthCheck { get; set; }

            [JsonProperty("Azure Storage Access 1")]
            public AzureStorageAccess1 AzureStorageAccess1 { get; set; }

            [JsonProperty("Vessel Tracker Image Token Config Check")]
            public VesselTrackerImageTokenConfigCheck VesselTrackerImageTokenConfigCheck { get; set; }

            [JsonProperty("Vessel Tracker Image API")]
            public VesselTrackerImageAPI VesselTrackerImageAPI { get; set; }

            [JsonProperty("Search Client Health Checks ")]
            public SearchClientHealthChecks SearchClientHealthChecks { get; set; }

            [JsonProperty("Index Health Checks ")]
            public IndexHealthChecks IndexHealthChecks { get; set; }

            [JsonProperty("Glencore Elastic Logging")]
            public GlencoreElasticLogging GlencoreElasticLogging { get; set; }

           


        [JsonProperty("CosmosDB Connection 1")]
            public CosmosDBConnection1 CosmosDBConnection1 { get; set; }

            [JsonProperty("CosmosDB ConnectionString Null")]
            public CosmosDBConnectionStringNull CosmosDBConnectionStringNull { get; set; }

            [JsonProperty("CosmosDB ConnectionString Regex")]
            public CosmosDBConnectionStringRegex CosmosDBConnectionStringRegex { get; set; }
        }

        public class GlencoreElasticLogging
        {
            public Data data { get; set; }
            public string description { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
            public List<object> tags { get; set; }
        }

        public class IndexHealthChecks
        {
            public Data data { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
            public List<object> tags { get; set; }
        }

        public class PositionHealthCheck
        {
            public Entries entries { get; set; }
            public string status { get; set; }
            public string totalDuration { get; set; }
        }

        public class RootHC
        {
            [JsonProperty("position-health-check")]
            public PositionHealthCheck PositionHealthCheck { get; set; }

            [JsonProperty("vessel-health-check")]
            public VesselHealthCheck VesselHealthCheck { get; set; }

            [JsonProperty("watchlist-health-check")]
            public WatchlistHealthCheck WatchlistHealthCheck { get; set; }

            [JsonProperty("shipsinpolygons-health")]
            public ShipsinpolygonsHealth ShipsinpolygonsHealth { get; set; }

            [JsonProperty("vesselimage-health")]
            public VesselimageHealth VesselimageHealth { get; set; }

            [JsonProperty("ship-to-ship-health-check")]
            public ShipToShipHealthCheck ShipToShipHealthCheck { get; set; }
        }

        public class SearchClientHealthChecks
        {
            public Data data { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
            public List<object> tags { get; set; }
        }

        public class ShipsinpolygonsHealth
        {
            public Entries entries { get; set; }
            public string status { get; set; }
            public string totalDuration { get; set; }
        }

        public class ShipToShipHealthCheck
        {
            public Entries entries { get; set; }
            public string status { get; set; }
            public string totalDuration { get; set; }
        }

        public class VesselHealthCheck
        {
            public Entries entries { get; set; }
            public string status { get; set; }
            public string totalDuration { get; set; }
        }

        public class VesselimageHealth
        {
            public Entries entries { get; set; }
            public string status { get; set; }
            public string totalDuration { get; set; }
        }

        public class VesselTrackerImageAPI
        {
            public Data data { get; set; }
            public string description { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
            public List<object> tags { get; set; }
        }

        public class VesselTrackerImageTokenConfigCheck
        {
            public Data data { get; set; }
            public string description { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
            public List<object> tags { get; set; }
        }

        public class WatchlistHealthCheck
        {
            public Entries entries { get; set; }
            public string status { get; set; }
            public string totalDuration { get; set; }
        }


    }


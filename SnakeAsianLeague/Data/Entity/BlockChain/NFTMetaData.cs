namespace SnakeAsianLeague.Data.Entity.BlockChain
{
    public class NFTMetaData
    {

        public Dictionary<int, string> metadataList { get; set; }
    }




    public class MetadataList {     
        //public List<Attributes> attributes { get; set;}
        public string properties { get; set;}
        public string description { get; set; }
        public string external_url { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string serialNumber { get; set; }
        public string animation_url { get; set; }
        public string LinkURL { get; set; }
    }






    public class Attributes
    { 
        public string trait_type { get; set; }

        public string value { get; set; }
    }






   


}



namespace SnakeAsianLeague.Data.Entity.BlockChain
{
    public class NFTMetaData
    {

        public Dictionary<decimal, string> metadataList { get; set; }
    }




    public class MetadataList {     

        public string TokenID { get; set; }
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



    public class PPSRMetadata_General
    {
        public List<attribute> attributes { get; set; }
        public string description { get; set; }
        public string external_url { get; set; }
        public string image { get; set; }
        public string original_name { get; set; }
        public string name { get; set; }
        public string serialNumber { get; set; }
    }


    public class attribute
    {
        public attribute() { }
        public attribute(string traitType, string value)
        {
            trait_type = traitType;
            this.value = value;
        }

        public attribute(string traitType, int value)
        {
            trait_type = traitType;
            this.value = value.ToString();
        }

        

        public string trait_type { get; set; }
        public string value { get; set; }
    }




}



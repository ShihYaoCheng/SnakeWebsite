namespace SnakeAsianLeague.Data.Entity.View
{

   

    public class TeachAllData {
        public int id { get; set; }
        public bool shine { get; set; }
        public string router { get; set; }
        public string title { get; set; }
        public AllTilte alltitle { get; set; }
    

        public TeachAllData(int Id, bool Shine, string Router, string Title, string SubTitle) {
            id = Id;
            shine = Shine;
            router = Router;
            title = Title;
            alltitle = new AllTilte( Title, SubTitle);
        }

        public class AllTilte
        {
            public string title { get; set; }
            public string subTitle { get; set; }

            public AllTilte(string Title, string SubTitle)
            {
                title = Title;
                subTitle = SubTitle;
            }
        }

        public void squareClick(string value)
        {
       
            if (router == value)
            {
                shine = true;
            }
            else
            {
                shine = false;
            }

        }
    }

    /*第一版
    public class Title
    {
        public string? MainTitle { get; set; }
        public string? SubTitle { get; set; }



        public Title(string main, string sub)
        {
            MainTitle = main;
            SubTitle = sub;
        }
    }

    */

    /*
     第二版
      public class TeachData
    {   //方框內的資料
        public string[][]? SquareData { get; set; }        
        //主標題跟副標題
        public string[][]? SetpTextData { get; set; }
        


        public TeachData(string[][] squareData, string[][] setpTextData ,string router)
        {
            SquareData = squareData;
            SetpTextData = setpTextData;
            this.init(router);
        }

        public  void init(string router)
        {
            foreach (var Data in this.SquareData)
            {
                if (Data[4] == router)
                {
                    Data[2] = "true";
                }
                else
                {
                    Data[2] = "false";
                }
            }
        }

        public void squareClick(string value)
        {
            foreach (var Data in this.SquareData)
            {
                if (Data[0] == value)
                {
                    Data[2] = "true";
                }
                else
                {
                    Data[2] = "false";
                }
            }
        }


    }

     */
}

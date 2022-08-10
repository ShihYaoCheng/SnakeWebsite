namespace SnakeAsianLeague.Data.Entity.View
{
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
}

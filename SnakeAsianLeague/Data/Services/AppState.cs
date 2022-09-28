using Microsoft.AspNetCore.Components;
using SnakeAsianLeague.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SnakeAsianLeague.Data.Services
{
    public class AppState
    {

        public SnakeAccount LoginStatus { get; private set; } = new SnakeAccount();
        public Lang nowLang { get; set; } = new Lang();

        public void UpdateLoginStatus(ComponentBase Source, SnakeAccount loginStatus) 
        {
            this.LoginStatus = loginStatus;
            NotifyStateChanged(Source , "LoginStatus");
        }

        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property)
            => StateChanged?.Invoke(Source, Property);

        public void getLang(string value) {
            this.nowLang.lang = value;
            getLangChanged(value);
        }
        public event Action<string> langChanged;
        private void getLangChanged(string value)
           => langChanged?.Invoke(value);


    }
}

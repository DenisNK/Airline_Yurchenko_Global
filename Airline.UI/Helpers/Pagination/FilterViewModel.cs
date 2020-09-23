using System.Collections.Generic;
using Airline.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airline_Yurchenko.Helpers.Pagination
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Team_Person> teams, int? team, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            teams.Insert(0, new Team_Person {Name_Team = "Все", Id = 0 });
            Companies = new SelectList(teams, "Id", "Name_Team", team);
            SelectedCompany = team;
            SelectedName = name;
        }
        public SelectList Companies { get; } // список компаний
        public int? SelectedCompany { get; }   // выбранная компания
        public string SelectedName { get; }    // введенное имя
    }
}

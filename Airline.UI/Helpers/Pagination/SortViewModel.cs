namespace Airline_Yurchenko.Helpers.Pagination
{
    public class SortViewModel
    {
        public SortState NameSort { get; } // значение для сортировки по имени
        public SortState AgeSort { get; }    // значение для сортировки по возрасту
        public SortState CompanySort { get; }   // значение для сортировки по команде
        public SortState Current { get; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            if (sortOrder == SortState.NameAsc)
                NameSort = SortState.NameDesc;
            else
                NameSort = SortState.NameAsc;
            AgeSort = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            CompanySort = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;
            Current = sortOrder;
        }
    }
}

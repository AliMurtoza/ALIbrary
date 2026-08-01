namespace ALIbrary.Application.Dashboard.DTOs;

using ALIbrary.Application.Books.DTOs;

public class DashboardResponse
{
    public int TotalBooks { get; set; }

    public int TotalAuthors { get; set; }

    public int ActiveLoans { get; set; }

    public int PendingReservations { get; set; }

    public List<BookResponse> RecentBooks { get; set; } = [];
}
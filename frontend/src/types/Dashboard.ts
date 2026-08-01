export interface Dashboard {
  totalBooks: number;
  totalAuthors: number;
  activeLoans: number;
  pendingReservations: number;

  recentBooks: DashboardBook[];
}

export interface DashboardBook {
  id: string;
  title: string;
  isbn: string;
  publishedYear: number;

  description: string;

  categoryName: string;
  publisherName: string;
  languageName: string;
}
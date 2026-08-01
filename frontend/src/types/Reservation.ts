export interface Reservation {
  id: string;
  memberId: string;
  bookId: string;
  bookTitle: string;
  reservedAt: string;
  status: number;
}
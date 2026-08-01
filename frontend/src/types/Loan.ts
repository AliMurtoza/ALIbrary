export interface Loan {
  id: string;

  memberId: string;
  memberName: string;

  bookCopyId: string;
  bookTitle: string;
  
  barcode: string;

  borrowedAt: string;
  dueAt: string;
  returnedAt?: string;

  status: number;
}

export interface BorrowBookRequest {
  memberId: string;
  bookCopyId: string;
}

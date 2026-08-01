import apiClient from "../api/apiClient";

import {
  Loan,
  BorrowBookRequest,
} from "../types/Loan";

export async function getLoans() {
  const response =
    await apiClient.get<Loan[]>("/Loans");

  return response.data;
}

export async function borrowBook(
  request: BorrowBookRequest
) {
  await apiClient.post("/Loans/borrow", request);
}

export async function returnBook(id: string) {
  await apiClient.post(`/Loans/${id}/return`);
}
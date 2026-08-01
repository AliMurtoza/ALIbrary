import apiClient from "../api/apiClient";

import {
    Book,
    CreateBookRequest,
    UpdateBookRequest,
} from "../types/Book";

export async function getBooks() {

    const response =
        await apiClient.get<Book[]>("/Books");

    return response.data;

}

export async function createBook(request: CreateBookRequest) {

    await apiClient.post("/Books", request);

}

export async function deleteBook(id: string) {
    await apiClient.delete(`/Books/${id}`);
}

export async function updateBook(
    id: string,
    request: UpdateBookRequest
) {
    await apiClient.put(`/Books/${id}`, request);
}
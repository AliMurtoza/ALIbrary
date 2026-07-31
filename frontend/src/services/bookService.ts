import apiClient from "../api/apiClient";
import { Book } from "../types/Book";

export async function getBooks() {

    const response =
        await apiClient.get<Book[]>("/Books");

    return response.data;

}
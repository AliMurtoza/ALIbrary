import apiClient from "../api/apiClient";

import {
  Author,
  CreateAuthorRequest,
} from "../types/Author";

export async function getAuthors() {
  const response =
    await apiClient.get<Author[]>("/Authors");

  return response.data;
}

export async function createAuthor(request: CreateAuthorRequest) {
  await apiClient.post("/Authors", request);
}

export async function updateAuthor(
  id: string,
  request: CreateAuthorRequest
) {
  await apiClient.put(`/Authors/${id}`, request);
}

export async function deleteAuthor(id: string) {
  await apiClient.delete(`/Authors/${id}`);
}
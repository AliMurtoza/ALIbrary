import apiClient from "../api/apiClient";
import { Lookup } from "../types/Lookup";

export async function getPublishers() {
    const response = await apiClient.get<Lookup[]>("/Publishers");
    return response.data;
}

export async function getLanguages() {
    const response = await apiClient.get<Lookup[]>("/Languages");
    return response.data;
}

export async function getCategories() {
    const response = await apiClient.get<Lookup[]>("/Categories");
    return response.data;
}
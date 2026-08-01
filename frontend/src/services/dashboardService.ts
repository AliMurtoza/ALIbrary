import apiClient from "../api/apiClient";
import { Dashboard } from "../types/Dashboard";

export async function getDashboard() {
  const response = await apiClient.get<Dashboard>("/Dashboard");

  return response.data;
}

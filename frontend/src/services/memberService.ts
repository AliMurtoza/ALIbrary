import apiClient from "../api/apiClient";

import { Member, CreateMemberRequest } from "../types/Member";

export async function getMembers() {
  const response = await apiClient.get<Member[]>("/Members");

  return response.data;
}

export async function createMember(request: CreateMemberRequest) {
  await apiClient.post("/Members", request);
}

export async function updateMember(id: string, request: CreateMemberRequest) {
  await apiClient.put(`/Members/${id}`, request);
}

export async function deleteMember(id: string) {
  await apiClient.delete(`/Members/${id}`);
}

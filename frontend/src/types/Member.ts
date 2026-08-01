export interface Member {
  id: string;

  userId: string;

  firstName: string;

  lastName: string;
}

export interface CreateMemberRequest {
  userId: string;

  firstName: string;

  lastName: string;
}

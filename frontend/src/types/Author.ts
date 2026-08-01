export interface Author {
  id: string;
  displayName: string;
  biography: string;
}

export interface CreateAuthorRequest {
  displayName: string;
  biography: string;
}
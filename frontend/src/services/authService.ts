import apiClient from "../api/apiClient";

import { LoginRequest } from "../types/LoginRequest";
import { LoginResponse } from "../types/LoginResponse";

export async function login(request: LoginRequest) {

    const response =
        await apiClient.post<LoginResponse>(
            "/Auth/login",
            request
        );

    return response.data;
}
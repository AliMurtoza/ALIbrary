import apiClient from "../api/apiClient";

import { Reservation } from "../types/Reservation";

export async function getReservations() {
    const response =
        await apiClient.get<Reservation[]>("/Reservations");

    return response.data;
}

export async function cancelReservation(id: string) {
    await apiClient.post(`/Reservations/${id}/cancel`);
}
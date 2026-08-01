import { useEffect, useState } from "react";

import {
  Button,
  Chip,
  CircularProgress,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  List,
  ListItem,
  ListItemText,
  Paper,
  Typography,
} from "@mui/material";

import { Reservation } from "../../types/Reservation";

import {
  getReservations,
  cancelReservation,
} from "../../services/reservationService";

export default function ReservationsPage() {
  const [reservations, setReservations] = useState<Reservation[]>([]);

  const [loading, setLoading] = useState(true);

  const [dialogOpen, setDialogOpen] = useState(false);

  const [selectedReservation, setSelectedReservation] =
    useState<Reservation | null>(null);

  async function loadReservations() {
    try {
      setReservations(await getReservations());
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => {
    loadReservations();
  }, []);

  async function confirmCancel() {
    if (!selectedReservation) return;

    await cancelReservation(selectedReservation.id);

    setDialogOpen(false);

    setSelectedReservation(null);

    await loadReservations();
  }

  if (loading) return <CircularProgress />;

  return (
    <>
      <Typography variant="h4" gutterBottom>
        Reservations
      </Typography>

      <Paper sx={{ p: 2 }}>
        <List>
          {reservations.map((reservation) => (
            <Paper
              key={reservation.id}
              elevation={1}
              sx={{
                mb: 2,
                p: 2,
                bgcolor: "#fafafa",
              }}
            >
              <ListItem
                disablePadding
                secondaryAction={
                  reservation.status === 0 && (
                    <Button
                      color="error"
                      variant="outlined"
                      onClick={() => {
                        setSelectedReservation(reservation);
                        setDialogOpen(true);
                      }}
                    >
                      Cancel
                    </Button>
                  )
                }
              >
                <ListItemText
                  primary={reservation.bookTitle}
                  secondary={
                    <>
                      Reserved:{" "}
                      {new Date(reservation.reservedAt).toLocaleDateString()}
                      <br />
                      <br />
                      <Chip
                        size="small"
                        label={
                          reservation.status === 0 ? "Pending" : "Cancelled"
                        }
                        color={reservation.status === 0 ? "warning" : "default"}
                      />
                    </>
                  }
                />
              </ListItem>
            </Paper>
          ))}
        </List>
      </Paper>

      <Dialog open={dialogOpen} onClose={() => setDialogOpen(false)}>
        <DialogTitle>Cancel Reservation</DialogTitle>

        <DialogContent>
          <Typography>
            Cancel reservation for
            <strong> {selectedReservation?.bookTitle}</strong>?
          </Typography>
        </DialogContent>

        <DialogActions>
          <Button onClick={() => setDialogOpen(false)}>No</Button>

          <Button color="error" variant="contained" onClick={confirmCancel}>
            Yes
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
}

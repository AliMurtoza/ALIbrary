import { useEffect, useState } from "react";

import {
  Box,
  Card,
  CardContent,
  CircularProgress,
  Grid,
  List,
  ListItem,
  ListItemText,
  Paper,
  Typography,
} from "@mui/material";

import { getDashboard } from "../../services/dashboardService";

import { Dashboard } from "../../types/Dashboard";

export default function DashboardPage() {
  const [dashboard, setDashboard] = useState<Dashboard | null>(null);

  useEffect(() => {
    async function load() {
      const result = await getDashboard();

      setDashboard(result);
    }

    load();
  }, []);

  if (!dashboard) {
    return <CircularProgress />;
  }

  return (
    <>
      <Box sx={{ p: 2 }}>
        <Typography variant="h4" gutterBottom>
          Dashboard
        </Typography>

        <Grid container spacing={2} sx={{ mb: 3 }}>
          <Grid size={{ xs: 12, md: 3 }}>
            <Card sx={{ bgcolor: "#e3f2fd" }}>
              <CardContent>
                <Typography color="text.secondary">Books</Typography>

                <Typography variant="h4">{dashboard.totalBooks}</Typography>
              </CardContent>
            </Card>
          </Grid>

          <Grid size={{ xs: 12, md: 3 }}>
            <Card sx={{ bgcolor: "#f3e5f5" }}>
              <CardContent>
                <Typography color="text.secondary">Authors</Typography>

                <Typography variant="h4">{dashboard.totalAuthors}</Typography>
              </CardContent>
            </Card>
          </Grid>

          <Grid size={{ xs: 12, md: 3 }}>
            <Card sx={{ bgcolor: "#e8f5e9" }}>
              <CardContent>
                <Typography color="text.secondary">Active Loans</Typography>

                <Typography variant="h4">{dashboard.activeLoans}</Typography>
              </CardContent>
            </Card>
          </Grid>

          <Grid size={{ xs: 12, md: 3 }}>
            <Card sx={{ bgcolor: "#fff3e0" }}>
              <CardContent>
                <Typography color="text.secondary">
                  Pending Reservations
                </Typography>

                <Typography variant="h4">
                  {dashboard.pendingReservations}
                </Typography>
              </CardContent>
            </Card>
          </Grid>
        </Grid>

        <Paper
          elevation={3}
          sx={{
            p: 2,
            bgcolor: "#fafafa",
          }}
        >
          <Typography variant="h6" gutterBottom>
            Recently Added Books
          </Typography>

          <List>
            {dashboard.recentBooks.map((book) => (
              <ListItem
                key={book.id}
                sx={{
                  mb: 1,
                  borderRadius: 2,
                  bgcolor: "#ffffff",
                  border: "1px solid #e0e0e0",
                }}
              >
                <ListItemText
                  primary={book.title}
                  secondary={`${book.publisherName} • ${book.categoryName} • ${book.publishedYear}`}
                />
              </ListItem>
            ))}
          </List>
        </Paper>
      </Box>
    </>
  );
}

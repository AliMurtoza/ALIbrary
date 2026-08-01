import { useEffect, useState } from "react";

import {
  CircularProgress,
  List,
  ListItem,
  ListItemText,
  Paper,
  Typography,
} from "@mui/material";

import { Loan } from "../../types/Loan";

import { getLoans } from "../../services/loanService";

export default function LoansPage() {
  const [loans, setLoans] = useState<Loan[]>([]);

  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function loadLoans() {
      try {
        setLoans(await getLoans());
      } finally {
        setLoading(false);
      }
    }

    loadLoans();
  }, []);

  if (loading) return <CircularProgress />;

  return (
    <>
      <Typography variant="h4" gutterBottom>
        Loans
      </Typography>

      <Paper sx={{ p: 2 }}>
        <List>
          {loans.map((loan) => (
            <ListItem key={loan.id} divider>
              <ListItemText
                primary={loan.bookTitle}
                secondary={
                  <>
                    Barcode: {loan.barcode}
                    <br />
                    Borrowed: {new Date(loan.borrowedAt).toLocaleDateString()}
                    <br />
                    Due: {new Date(loan.dueAt).toLocaleDateString()}
                  </>
                }
              />
            </ListItem>
          ))}
        </List>
      </Paper>
    </>
  );
}

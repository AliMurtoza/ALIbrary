import { Typography } from "@mui/material";

export default function DashboardPage() {

    return (

        <>
            <Typography variant="h4">
                Dashboard
            </Typography>

            <Typography sx={{ mt: 2 }}>
                You are successfully authenticated.
            </Typography>
        </>

    );

}
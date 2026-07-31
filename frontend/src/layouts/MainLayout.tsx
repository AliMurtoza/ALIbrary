import { Outlet } from "react-router-dom";

import {
    AppBar,
    Box,
    CssBaseline,
    Drawer,
    List,
    ListItem,
    ListItemButton,
    ListItemText,
    Toolbar,
    Typography,
} from "@mui/material";

const drawerWidth = 240;

export default function MainLayout() {

    return (
        <Box sx={{ display: "flex" }}>

            <CssBaseline />

            <AppBar
                position="fixed"
                sx={{
                    zIndex: (theme) => theme.zIndex.drawer + 1,
                }}
            >
                <Toolbar>

                    <Typography variant="h6">

                        ALIbrary

                    </Typography>

                </Toolbar>

            </AppBar>

            <Drawer
                variant="permanent"
                sx={{
                    width: drawerWidth,
                    flexShrink: 0,
                    "& .MuiDrawer-paper": {
                        width: drawerWidth,
                        boxSizing: "border-box",
                    },
                }}
            >

                <Toolbar />

                <List>

                    <ListItem disablePadding>
                        <ListItemButton>

                            <ListItemText primary="Dashboard" />

                        </ListItemButton>
                    </ListItem>

                    <ListItem disablePadding>
                        <ListItemButton>

                            <ListItemText primary="Books" />

                        </ListItemButton>
                    </ListItem>

                    <ListItem disablePadding>
                        <ListItemButton>

                            <ListItemText primary="Authors" />

                        </ListItemButton>
                    </ListItem>

                    <ListItem disablePadding>
                        <ListItemButton>

                            <ListItemText primary="Loans" />

                        </ListItemButton>
                    </ListItem>

                    <ListItem disablePadding>
                        <ListItemButton>

                            <ListItemText primary="Reservations" />

                        </ListItemButton>
                    </ListItem>

                </List>

            </Drawer>

            <Box
                component="main"
                sx={{
                    flexGrow: 1,
                    p: 3,
                }}
            >

                <Toolbar />

                <Outlet />

            </Box>

        </Box>
    );
}
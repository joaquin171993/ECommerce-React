import React from "react";
import {
  Container,
  Card,
  Grid,
  Typography,
  Icon,
  Avatar,
  TextField,
  Button,
} from "@material-ui/core";
import useStyles from "../../theme/useStyles";
import { Link } from "react-router-dom";

export default function Login() {
  const classes = useStyles();
  return (
    <Container className={classes.containermt}>
      <Grid container justifyContent="center">
        <Grid item lg={5} md={6}>
          <Card align="center" className={classes.card}>
            <Avatar className={classes.avatar}>
              <Icon className={classes.icon}>person</Icon>
            </Avatar>
            <Typography variant="h5" color="primary">
              Ingrese su usuario
            </Typography>
            <form className={classes.form}>
              <Grid container spacing={2} className={classes.gridmb}>
                <Grid item xs={12}>
                  <TextField
                    label="Email"
                    variant="outlined"
                    fullWidth
                    type="email"
                  ></TextField>
                </Grid>
                <Grid item xs={12} className={classes.gridmb}>
                  <TextField
                    label="Password"
                    variant="outlined"
                    fullWidth
                    type="password"
                  ></TextField>
                </Grid>
              </Grid>
              <Grid item xs={12}>
                <Button
                  className={classes.gridmb}
                  color="primary"
                  variant="contained"
                  fullWidth
                  type="password"
                >
                  Iniciar Sesión
                </Button>
              </Grid>
              <Link className={classes.link} to="/registrar" variant="body1">
                ¿No tiene cuenta? Regístrate
              </Link>
            </form>
          </Card>
        </Grid>
      </Grid>
    </Container>
  );
}

import {
  AppBar,
  Toolbar,
  Container,
  Typography,
  Icon,
  Button,
  IconButton,
  ListItemIcon,
  ListItemText,
  Drawer,
  List,
  ListItem,
} from "@material-ui/core";
import React, { useState } from "react";
import useStyles from "../../theme/useStyles";
import { Link } from "react-router-dom";

const MenuAppBar = () => {
  const classes = useStyles();

  /*se recomienda usar useRef() en este caso, para tomarlo en cuenta */
  const [open, setOpen] = useState(false);

  const openToggle = () => {
    setOpen(true);
  };

  const closeToggle = () => {
    setOpen(false);
  };

  return (
    <div>
      <AppBar position="static" className={classes.appBar}>
        <Container>
          <Toolbar>
            <div className={classes.sectionMobile}>
              <IconButton color="inherit" onClick={openToggle}>
                <Icon fontSize="large">menu</Icon>
              </IconButton>
            </div>
            <Drawer open={open} onClose={closeToggle}>
              <div className={classes.list}>
                <List>
                  <ListItem
                    onClick={closeToggle}
                    button
                    className={classes.listItem}
                  >
                    <Link
                      to="/login"
                      color="inherit"
                      underline="none"
                      className={classes.linkAppBarMobile}
                    >
                      <ListItemIcon className={classes.listItemIcon}>
                        <Icon className={classes.mr}>person</Icon>
                        <ListItemText>Login</ListItemText>
                      </ListItemIcon>
                    </Link>
                  </ListItem>
                </List>
              </div>
            </Drawer>
            <div className={classes.grow}>
              <Link
                to="/"
                color="inherit"
                underline="none"
                className={classes.linkAppBarLogo}
              >
                <Icon fontSize="large" className={classes.mr}>
                  store
                </Icon>
                <Typography variant="h5">VAXI SHOP</Typography>
              </Link>
            </div>
            <div className={classes.sectionDesktop}>
              <Button color="inherit" className={classes.buttonIcon}>
                <Link
                  to="/login"
                  color="inherit"
                  underline="none"
                  className={classes.linkAppBarDesktop}
                >
                  <Icon className={classes.mr}>person</Icon>
                  Login
                </Link>
              </Button>
            </div>
          </Toolbar>
        </Container>
      </AppBar>
    </div>
  );
};

export default MenuAppBar;

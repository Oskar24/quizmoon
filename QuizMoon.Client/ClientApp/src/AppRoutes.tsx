import React, { ReactElement } from "react";
import Home from "./components/home/Home";

interface Route {
  path: string;
  element?: ReactElement;
  errorElement?: ReactElement;
}
const AppRoutes: Route[] = [
  {
    path: "/",
    element: <Home />,
    errorElement: <div>Something went wrong</div>
  },
  {
    path: "/test",
    element: <div>Test</div>
  }
];

export default AppRoutes;

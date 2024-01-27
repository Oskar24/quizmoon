import Home from "./components/home/Home";

const AppRoutes = [
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

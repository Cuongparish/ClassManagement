import routes from "./routes";
import EmptyLayout from "./layouts/EmptyLayout";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from 'react-router-dom';

function App() {
  return (
    <Router>
        <Routes>
          {routes.map((route, index) => {
            const Layout = route.layout || EmptyLayout;
            const Page = route.page;
            // const role = route.role;
            const Element = () => (
              <Layout>
                <Page />
              </Layout>
            );
            return (
              <Route
                key={index}
                path={route.path}
                element={
                  <Element />
                }
              />
            );
          })}
          {/*  */}
          <Route path="*" element={<Navigate to="/" />} />
          <Route path="/" element={<Navigate to="/introduction" />} />
        </Routes>
    </Router>
  )
}

export default App

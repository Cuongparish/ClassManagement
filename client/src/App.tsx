import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from 'react-router-dom';
import routes from './routes';
import EmptyLayout from './layouts/EmptyLayout';
import { useUser } from './utils/UserContext';

function App() {
  const { user } = useUser();

  return (
    <Router>
      <Routes>
        {routes.map((route, index) => {
          const Layout = route.layout || EmptyLayout;
          const Page = route.page;

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
                route.requiresAuth
                  ? (user ? <Element /> : <Navigate to="/login" />)
                  : <Element />
              }
            />
          );
        })}
        <Route path="/" element={<Navigate to="/introduction" />} />
        <Route path="*" element={<Navigate to="/" />} />
      </Routes>
    </Router>
  );
}

export default App;

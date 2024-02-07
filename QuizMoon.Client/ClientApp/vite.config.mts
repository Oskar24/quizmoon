import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import viteTsconfigPaths from 'vite-tsconfig-paths'

export default defineConfig({
    base: '',
    plugins: [react(), viteTsconfigPaths()],
    server: {
        open: true,
        port: 44419,
        proxy: {
            '/account': {
                target: 'https://localhost:7204',
                changeOrigin: true,
                secure: false,
            },
            '/api': {
                target: 'https://localhost:7204',
                changeOrigin: true,
                secure: false,
            },
            '/css': {
                target: 'https://localhost:7204',
                changeOrigin: true,
                secure: false,
            },
            '/img': {
                target: 'https://localhost:7204',
                changeOrigin: true,
                secure: false,
            }
        }
    },
})
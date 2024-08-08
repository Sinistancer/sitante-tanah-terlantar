/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.{razor,html,cshtml}",
        "./node_modules/flowbite/**/*.js"
    ],
    theme: {
        extend: {
            width: {
                '180': '50rem',
                '88': '22rem',
                '50': '12.5rem', // Setara dengan w-50
                '55': '13.75rem', // Setara dengan w-55
                '63': '15.75rem', // Setara dengan w-55
                '25': '6.25rem',
                '28': '7rem',
                '30': '7.5rem'
            },
            borderRadius: {
                'large': '0.75rem'
            },
            margin: {
                '9.6px': '0.6rem',
                '1.25': '1.25rem'
            }
        }
    },
    plugins: [
        require('flowbite/plugin')
    ],
}
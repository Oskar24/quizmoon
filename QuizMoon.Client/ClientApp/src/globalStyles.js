import { createGlobalStyle } from "styled-components";
import * as COLORS from './constants/Colors';
import * as SIZES from './constants/Sizes';

const GlobalStyles = createGlobalStyle`
    html {
        height: 100%;
        width: 100%;
    }

    body {
        height: 100%;
        width: 100%;
        
        color: ${COLORS.MAIN_FONT};
        font-family: 'Segoe UI Light', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        font-size: ${SIZES.FONT_REGULAR};
    }

    #root{
        height: 100%;
        width: 100%;
    }
`;

export default GlobalStyles;
import { createGlobalStyle } from "styled-components";
import * as COLORS from './constants/Colors';
import * as SIZES from './constants/Sizes';

const GlobalStyles = createGlobalStyle`
    html, body, #root {
        height: 100%;
        width: 100%;
        margin: 0px;
    }

    * {
        color: ${COLORS.MAIN_FONT};
        font-family: 'Segoe UI Light', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        font-size: ${SIZES.FONT_REGULAR};
    }

`;

export default GlobalStyles;
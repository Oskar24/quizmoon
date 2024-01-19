import styled from "styled-components";

const StyledHeader = styled.div`
    height: 100%;
`;

const LogoImage = styled.img`
    max-height: 100%;
    width: 76px;
`;

const LogoText = styled.img`
    max-height: 100%;
    width: 240px;
    margin-left: 14px

`;

const Header = () => {

    return(
        <StyledHeader>
            <LogoImage src="/Astro.png" alt="Logo" class="logo"/>
            <LogoText src="/Quizmoon.png" alt="Logo" class="logo"/>
        </StyledHeader>
    )
}

export default Header;
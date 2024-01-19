import styled from "styled-components";
import * as COLORS from '../../constants/Colors';
import Button from "../common/Button";

const Panel = styled.div`
    display: flex;
    flex-direction: column;
    background: ${COLORS.MAIN_BACKGROUND_DARK};
    border-right: 1px solid #555;

    position: fixed;
    width: inherit;
    height: 100%;
`;

const LogoImageContainer = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
`;

const LogoImage = styled.img`
    width: 70px;
    margin: 10px;
`;


const LogoText = styled.img`
    width: 200px;
`;

const MenuItems = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;

    margin-top: 40px;
`;

const LeftPanel = () => {
    return (
        <Panel>
            <LogoImageContainer>
                <LogoImage src="/Astro.png" alt="Logo" class="logo" />
                <LogoText src="/Quizmoon.png" alt="Logo" class="logo" />
            </LogoImageContainer>
            <MenuItems>
                <Button label="Login" variant="primary"></Button>
                <Button label="About"></Button>
                <Button label="My progress"></Button>
                <Button label="My tests"></Button>
            </MenuItems>
        </Panel>
    )
}

export default LeftPanel;
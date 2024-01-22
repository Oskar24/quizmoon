import styled from "styled-components";
import * as COLORS from '../../constants/Colors';
import Button from "../common/Button";
import fetchUser from "../../hooks/UserHooks";
import { useState, useEffect } from "react";

const Panel = styled.div`
    display: flex;
    flex-direction: column;
    background: ${COLORS.MAIN_BACKGROUND_DARK};
    border: 1px solid ${COLORS.MAIN_BORDER};

    position: fixed;
    width: 250px;
    height: 100%;
`;

const LogoImageContainer = styled.div`
    flex: 0 0 auto;
    display: flex;
    flex-direction: column;
    align-items: center;
`;

const MenuItems = styled.div`
    flex: 1 1 auto;

    display: flex;
    flex-direction: column;
    align-items: center;

    margin-top: 30px;
`;

const UserButtonsContainer = styled.div`
    flex: 0 0 auto;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    
    border-top: 1px solid ${COLORS.MAIN_THEME_1};
    border-bottom: 1px solid ${COLORS.MAIN_BORDER};
`;

const LogoImage = styled.img`
    width: 70px;
    margin-top: 20px;
`;

const LogoText = styled.img`
    margin-top: 10px;
    width: 200px;
`;

const UserName = styled.div`
    width: 80px;
    height: 40px;
    text-align: center;
    line-height: 40px;
    position: relative;
    
    &:after {
        content: '';
        position: absolute;
        bottom: 10%;
        left: 50%;
        transform: translateX(-50%);
        width: 30%;
        height: 1px;
        background-color: ${COLORS.MAIN_THEME_1};
        transition: all 0.15s ease;
  }
`;

function redirectToLogin() {
    window.location.href = "account/Login";
}

function redirectToLogout() {
    window.location.href = "account/Logout";
}

const LeftPanel = () => {
    const [userClaims, setUserClaims] = useState(null);

    const fetchUserData = async () => {
        try {
            const response = await fetchUser();
            if (response && response.data) {
                setUserClaims(response.data);
            }
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    const getClaimValue = (type) => {
        const claim = userClaims.find(claim => claim.type === type);
        return claim ? claim.value : null;
    };

    useEffect(() => {
        fetchUserData();
    }, []);

    return (
        <Panel>
            <LogoImageContainer>
                <LogoImage src="/Astro.png" alt="Logo" />
                <LogoText src="/Quizmoon.png" alt="Logo" />
            </LogoImageContainer>
            <MenuItems>
                <Button label="About"></Button>
                <Button label="My progress"></Button>
                <Button label="My tests"></Button>
            </MenuItems>
            <UserButtonsContainer>
                {userClaims ?
                    <>
                        <UserName>{getClaimValue('http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name')}</UserName>
                        <Button label="Logout" variant="primary" size="small" onClick={redirectToLogout}></Button>
                    </>
                    :
                    <>
                        <Button label="Login" variant="primary" size="small" onClick={redirectToLogin}></Button>
                        <Button label="Register" variant="primary" size="small" ></Button>
                    </>
                }
            </UserButtonsContainer>
        </Panel>
    )
}

export default LeftPanel;
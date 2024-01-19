import styled from "styled-components";

const StyledPanel = styled.div`
`;


const LogoTextContainer = styled.div`
    height: 80px;
    display: flex;
    align-items: center;
`;


const Content = styled.div`
    margin-top: 60px;
    display: flex;
    flex-direction: column;
    align-items: center;
`;

const StyledItem = styled.div`
    height: 440px;
    width: 600px;
    border: 1px solid #777;
    border-radius: 20px;
    margin: 20px;

    line-height: 440px;
    text-align: center;
`;

const RightPanel = () => {

    const testTable = Array.from({ length: 30 }, (_, index) => index + 1);



    return (
        <StyledPanel>
            <LogoTextContainer>
            </LogoTextContainer>
            <Content>
                {testTable.map(item => <StyledItem>Abc_{item}</StyledItem>)}
            </Content>
        </StyledPanel>
    )
}

export default RightPanel;
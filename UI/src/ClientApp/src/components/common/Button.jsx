import React from 'react';
import styled from 'styled-components';
import * as COLORS from '../../constants/Colors';

const StyledButton = styled.button`
  position: relative;
  background: transparent;
  color: inherit;
  border: none;
  height: 40px;
  width: 120px;
  margin: 5px;
  transition: all 0.15s ease;

  &:after {
    content: '';
    position: absolute;
    bottom: 10%;
    left: 50%;
    transform: translateX(-50%);
    width: 0%;
    height: 1px;
    background-color: ${(props) => props.variant === 'primary' ? COLORS.MAIN_THEME_1 : COLORS.MAIN_THEME_2};
    transition: all 0.15s ease;
  }

  &:hover:after {
    width: 30%;
  }

  &:hover{
    color: ${(props) => props.variant === 'primary' ? COLORS.MAIN_THEME_1 : COLORS.MAIN_THEME_2};
  }
`;

const Button = ({ label, variant, onClick }) => {
  return(
  <StyledButton onClick={onClick} variant={variant}>
    {label}
  </StyledButton>
  );
};

export default Button;
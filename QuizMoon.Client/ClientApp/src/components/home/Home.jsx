import React, { useEffect, useState } from 'react';
import axios from 'axios';
import styled from 'styled-components';
import * as COLORS from '../../constants/Colors';
import * as SIZES from '../../constants/Sizes';

const HomePage = styled.div``;

const Title = styled.div`
    height: 120px;
    line-height: 120px;
    text-align: center;
    font-size: ${SIZES.FONT_EXTRA_LARGE};
    color: ${COLORS.MAIN_THEME_1};
`;

const FlashcardsContainer = styled.div`
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    justify-content: center;
`;

const FlashcardBorder = styled.div`
    background-color: ${COLORS.MAIN_BACKGROUND_DARK};
    border: 1px solid ${COLORS.MAIN_BORDER};
    box-shadow: 0px 0px 10px 0px ${COLORS.MAIN_BACKGROUND_DARK};
    border-radius: 20px;
    margin: 60px;
    width: 400px;
    min-height: 260px;
    text-align: center;
    display: flex;
    flex-direction: column;
    justify-content: center;
    cursor: pointer;
    transition: transform 0.5s, border-color 0.5s;
    transform-style: preserve-3d;

    &.flipped {
        transform: rotateY(180deg);
        border-color: ${COLORS.MAIN_THEME_2}; /* Kolor ramki dla strony z odpowiedzią po odwróceniu */
    }

    &.question {
        border: 1px solid ${COLORS.MAIN_THEME_1}; /* Kolor ramki dla strony z pytaniem */
    }
`;

const FlashcardContent = styled.div`
    backface-visibility: hidden;
    transform: rotateY(0deg);
    transition: transform 0.5s;
    margin: 20px;
`;

const FlashcardQuestion = styled.div`
    font-weight: bold;
`;

const FlashcardAnswer = styled.div`
    margin-top: 40px;
`;

const Home = () => {
    const [flashcards, setFlashcards] = useState([]);
    const [loading, setLoading] = useState(true);
    const [flippedCard, setFlippedCard] = useState(null);
    const [prevFlippedCard, setPrevFlippedCard] = useState(null);

    useEffect(() => {
        const fetchFlashcards = async () => {
            try {
                const response = await axios.get('/api/Flashcard');
                setFlashcards(response.data);
                setLoading(false);
            } catch (error) {
                console.error('Error fetching flashcards:', error);
            }
        };

        fetchFlashcards();
    }, []);

    const handleCardClick = (cardId) => {
        if (flippedCard === null) {
            setFlippedCard(cardId);
        }
        else {
            if (flippedCard === cardId) {
                setPrevFlippedCard(null);
                setFlippedCard(null);
            }
            else {
                setPrevFlippedCard(flippedCard);
                setFlippedCard(cardId);

                setTimeout(() => {
                    setPrevFlippedCard(null);
                }, 500);
            }
        }
    };

    return (
        <HomePage>
            {loading ? (
                <p>Loading...</p>
            ) : (
                <>
                    <Title>Flashcards</Title>
                    <FlashcardsContainer>
                        {flashcards.map((flashcard) => (
                            <FlashcardBorder
                                key={flashcard.id}
                                className={`${flippedCard === flashcard.id ? 'flipped' : ''
                                    } ${flippedCard === flashcard.id ? 'answer' : 'question'} ${prevFlippedCard === flashcard.id ? 'flipped' : ''
                                    } ${prevFlippedCard === flashcard.id ? 'question' : ''}`}
                                onClick={() => handleCardClick(flashcard.id)}
                            >
                                <FlashcardContent>
                                    <FlashcardQuestion>{flashcard.question}</FlashcardQuestion>
                                </FlashcardContent>
                                <FlashcardContent style={{ transform: 'rotateY(180deg)' }}>
                                    <FlashcardAnswer>{flashcard.answer}</FlashcardAnswer>
                                </FlashcardContent>
                            </FlashcardBorder>
                        ))}
                    </FlashcardsContainer>
                </>
            )}
        </HomePage>
    );
};

export default Home;

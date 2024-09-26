const showStatisticsButtonElement = $('#statistics-button');
const statisticsDivElement = $('#statistics');
const totalHousesH2Element = $('#total-houses');
const totalRentsH2Element = $('#total-rents');

showStatisticsButtonElement.on('click', showOrHideStatistics);

function showOrHideStatistics() {
    if (showStatisticsButtonElement.text() === 'Show Statistics') {
        $.get('/api/statistic', (data) => {
            totalHousesH2Element.text(data.totalHousesCount + " Houses");
            totalRentsH2Element.text(data.rentedHousesCount + " Rents");
            statisticsDivElement.removeClass('d-none');
            showStatisticsButtonElement.text('Hide Statistics');
        });
    } else {
        statisticsDivElement.addClass('d-none');
        showStatisticsButtonElement.text('Show Statistics');
    }
}
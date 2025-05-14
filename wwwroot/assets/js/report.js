// Set current date
const currentDateElement = document.getElementById("currentDate");
const today = new Date();
const options = {
  weekday: "long",
  year: "numeric",
  month: "long",
  day: "numeric",
};
currentDateElement.textContent = today.toLocaleDateString("th-TH", options);

// Set default date range
const endDateInput = document.getElementById("endDate");
const startDateInput = document.getElementById("startDate");
endDateInput.valueAsDate = today;

const oneMonthAgo = new Date(today);
oneMonthAgo.setMonth(today.getMonth() - 1);
startDateInput.valueAsDate = oneMonthAgo;

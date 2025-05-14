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

// Set today's date as default for the date input
document.getElementById("receiveDate").valueAsDate = today;

// Product data (simulated database)
const products = {
  P001: { name: "สินค้า A", unit: "ชิ้น", price: 150 },
  P002: { name: "สินค้า B", unit: "กล่อง", price: 480 },
  P003: { name: "สินค้า C", unit: "ชุด", price: 750 },
};

let rowCount = 0;
let total = 0;

// Add product row to table
function addProductRow() {
  const productSelect = document.getElementById("productSelect");
  const productId = productSelect.value;

  if (!productId) {
    alert("กรุณาเลือกสินค้า");
    return;
  }

  const product = products[productId];
  rowCount++;

  const tableBody = document.getElementById("productTableBody");
  const newRow = document.createElement("tr");
  newRow.id = `row-${rowCount}`;

  newRow.innerHTML = `
          <td>${rowCount}</td>
          <td>${product.name} (${productId})</td>
          <td>
            <input type="number" class="form-control" value="1" min="1" onchange="updateRowTotal(${rowCount})">
          </td>
          <td>${product.unit}</td>
          <td>
            <input type="number" class="form-control" value="${
              product.price
            }" onchange="updateRowTotal(${rowCount})">
          </td>
          <td class="row-total">${product.price.toFixed(2)}</td>
          <td>
            <button type="button" class="action-btn" onclick="removeRow(${rowCount})">
              <i class="bx bx-trash"></i>
            </button>
          </td>
        `;

  tableBody.appendChild(newRow);
  total += product.price;
  updateTotal();

  // Reset product select
  productSelect.value = "";
}

// Update row total
function updateRowTotal(rowId) {
  const row = document.getElementById(`row-${rowId}`);
  const quantity = parseFloat(
    row.querySelector('input[type="number"]:nth-of-type(1)').value
  );
  const price = parseFloat(
    row.querySelector('input[type="number"]:nth-of-type(2)').value
  );
  const rowTotal = quantity * price;

  row.querySelector(".row-total").textContent = rowTotal.toFixed(2);
  updateTotal();
}

// Remove row
function removeRow(rowId) {
  const row = document.getElementById(`row-${rowId}`);
  row.remove();
  updateTotal();
}

// Update total amount
function updateTotal() {
  const rowTotals = document.querySelectorAll(".row-total");
  total = 0;

  rowTotals.forEach((cell) => {
    total += parseFloat(cell.textContent);
  });

  document.getElementById("totalAmount").textContent = total.toFixed(2);
}

// Form submission
document.getElementById("stockInForm").addEventListener("submit", function (e) {
  e.preventDefault();

  const rows = document.querySelectorAll("#productTableBody tr");
  if (rows.length === 0) {
    alert("กรุณาเพิ่มสินค้าอย่างน้อย 1 รายการ");
    return;
  }

  // Here you would normally send the data to the server
  alert("บันทึกการรับเข้าสินค้าเรียบร้อยแล้ว");

  // For demo, add to the recent stock list
  const supplier = document.getElementById("supplier");
  const supplierText = supplier.options[supplier.selectedIndex].text;
  const receiptNumber = document.getElementById("receiptNumber").value;
  const referenceNumber = document.getElementById("referenceNumber").value;

  const recentStockList = document.querySelector(".stock-list tbody");
  const newRecentRow = document.createElement("tr");

  newRecentRow.innerHTML = `
          <td>${receiptNumber}</td>
          <td>${today.toLocaleDateString("th-TH")}</td>
          <td>${supplierText}</td>
          <td>${referenceNumber}</td>
          <td>${rows.length}</td>
          <td>${total.toFixed(2)}</td>
          <td><span class="status status-success">สำเร็จ</span></td>
          <td>
            <button class="action-btn"><i class="bx bx-show"></i></button>
            <button class="action-btn"><i class="bx bx-printer"></i></button>
          </td>
        `;

  recentStockList.insertBefore(newRecentRow, recentStockList.firstChild);

  // Reset form
  document.getElementById("stockInForm").reset();
  document.getElementById("productTableBody").innerHTML = "";
  document.getElementById("receiveDate").valueAsDate = today;
  document.getElementById("receiptNumber").value = "RCV-2505120001";
  total = 0;
  updateTotal();
});

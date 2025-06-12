// Set current date
const currentDateOut = document.getElementById('currentDate');
if (currentDateOut) {
  const d = new Date();
  currentDateOut.textContent = d.toLocaleDateString('th-TH', { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' });
  document.getElementById('issueDate').valueAsDate = d;
}

let products = {};
async function loadProducts() {
  try {
    const res = await fetch('/api/products');
    if (!res.ok) throw new Error('Failed to load products');
    const data = await res.json();
    products = {};
    const select = document.getElementById('productSelect');
    select.innerHTML = '<option value="">เลือกสินค้าที่ต้องการเบิกออก</option>';
    data.forEach(p => {
      products[p.id] = { name: p.name, unit: '', stock: p.stock };
      const opt = document.createElement('option');
      opt.value = p.id;
      opt.textContent = `${p.name} - ${p.id}`;
      select.appendChild(opt);
    });
  } catch (err) {
    console.error(err);
  }
}
loadProducts();

let rowCount = 0;
function addProductRow() {
  const select = document.getElementById('productSelect');
  const id = select.value;
  if (!id) return alert('กรุณาเลือกสินค้า');
  const product = products[id];
  rowCount++;
  const body = document.getElementById('productTableBody');
  const tr = document.createElement('tr');
  tr.id = `row-${rowCount}`;
  tr.dataset.productId = id;
  tr.innerHTML = `
    <td>${rowCount}</td>
    <td>${product.name} (${id})</td>
    <td>${product.stock}</td>
    <td><input type="number" class="form-control" value="1" min="1"></td>
    <td>${product.unit}</td>
    <td></td>
    <td><button type="button" class="action-btn" onclick="removeRow(${rowCount})"><i class="bx bx-trash"></i></button></td>
  `;
  body.appendChild(tr);
  select.value = '';
  updateTotal();
}

function removeRow(id) {
  const row = document.getElementById(`row-${id}`);
  if (row) row.remove();
  updateTotal();
}

function updateTotal() {
  document.getElementById('totalItems').textContent = document.querySelectorAll('#productTableBody tr').length;
}

document.getElementById('stockOutForm').addEventListener('submit', async function(e) {
  e.preventDefault();
  const rows = document.querySelectorAll('#productTableBody tr');
  if (rows.length === 0) return alert('กรุณาเพิ่มสินค้าอย่างน้อย 1 รายการ');
  for (const row of rows) {
    const id = row.dataset.productId;
    const qty = parseFloat(row.querySelector('input[type="number"]').value);
    const payload = {
      quantity: qty,
      deliverySlipNumber: document.getElementById('issueNumber').value,
      receiptNumber: document.getElementById('referenceNumber').value
    };
    try {
      const res = await fetch(`/api/products/${id}/withdraw`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
      });
      if (!res.ok) {
        const text = await res.text();
        alert(text);
        return;
      }
    } catch (err) {
      console.error(err);
      alert('Error while saving data');
      return;
    }
  }
  alert('บันทึกการเบิกสินค้าเรียบร้อยแล้ว');
  document.getElementById('stockOutForm').reset();
  document.getElementById('productTableBody').innerHTML = '';
  updateTotal();
});

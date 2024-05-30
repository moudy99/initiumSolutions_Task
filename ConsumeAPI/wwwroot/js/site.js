document.addEventListener('DOMContentLoaded', function () {
    flatpickr('.flatpickr', {
        dateFormat: "Y-m-d",
        minDate: "today"
    });

    const bookingForm = document.getElementById('bookingForm');
    const nextButton = document.getElementById('nextButton');
    const prevButton = document.getElementById('prevButton');
    const numberOfRoomsInput = document.getElementById('numberOfRooms');
    const addRoomButton = document.getElementById('addRoomButton');
    const step1 = document.getElementById('step1');
    const step2 = document.getElementById('step2');
    const roomDetailsContainer = document.getElementById('roomDetailsContainer');
    const roomTypes = ["Single", "Double", "Suite"];
    let formSubmitted = false;


    bookingForm.addEventListener('submit', function (event) {
        event.preventDefault();

        if (formSubmitted) {
            return;
        }

        const roomInputsFilled = Array.from(roomDetailsContainer.querySelectorAll('select, input')).every(input => input.value.trim() !== '');
        if (!roomInputsFilled) {
            Swal.fire({
                icon: 'error',
                title: 'Validation Error',
                text: 'Fill the room information.',
            });
            return;
        }

        formSubmitted = true; 

        const formData = new FormData(bookingForm);
        const formObject = Object.fromEntries(formData.entries());

        const roomDetails = [];
        roomDetailsContainer.querySelectorAll('.room-detail').forEach((roomDetail, index) => {
            const roomType = formData.get(`RoomBookings[${index}].RoomType`);
            const numberOfAdults = formData.get(`RoomBookings[${index}].NumberOfAdults`);
            const numberOfChildren = formData.get(`RoomBookings[${index}].NumberOfChildren`);
            roomDetails.push({ Type: roomType, NumberOfAdults: parseInt(numberOfAdults), NumberOfChildren: parseInt(numberOfChildren) });
        });

        const bookingData = {
            CustomerName: formObject.CustomerName,
            NationalID: formObject.NationalID,
            PhoneNumber: formObject.PhoneNumber,
            BranchID: parseInt(formObject.BranchID),
            CheckInDate: formObject.CheckInDate,
            CheckOutDate: formObject.CheckOutDate,
            Rooms: roomDetails
        };
        fetch('/Hotel/BookRoom', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(bookingData)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('error in network');
                }
                return response.json();
            })
            .then(data => {
                console.log(data)
                if (data.succeeded) {
                    const successText = data.discountApplied ? "your booking is successful. Congratulations you have taken a 5% discount" : "Your booking is successful. Enjoy your stay";
                    return Swal.fire({
                        icon: 'success',
                        title: 'Booking Successful',
                        text: successText
                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.reload();
                        }
                    });
                } else {
                    throw new Error(data.message);
                }
            })
            .catch(error => {
                console.error('Error:', error);
                Swal.fire({
                    icon: 'error',
                    title: 'Booking Failed',
                    text: 'There was an error. Please try again.'
                });
            });

    });

    nextButton.addEventListener('click', function () {
        const currentStepFields = step1.querySelectorAll('input, select');
        let isValid = true;

        currentStepFields.forEach(field => {
            if (!field.checkValidity()) {
                field.reportValidity();
                isValid = false;
            }
        });

        if (!isValid) {
            Swal.fire({
                icon: 'error',
                title: 'Validation Error',
                text: ' complete all required fields before.',
            });
            return;
        }

        const formData = new FormData(bookingForm);
        const checkInDate = new Date(formData.get('CheckInDate'));
        const checkOutDate = new Date(formData.get('CheckOutDate'));
        if (checkInDate >= checkOutDate) {
            Swal.fire({
                icon: 'error',
                title: 'Validation Error',
                text: 'Check-out date must be after check-in date',
            });
            return;
        }

        const numberOfRooms = numberOfRoomsInput.value;
        if (numberOfRooms > 0) {
            roomDetailsContainer.innerHTML = '';
            for (let i = 0; i < numberOfRooms; i++) {
                addRoomDetail(i);
            }
            step1.style.display = 'none';
            step2.style.display = 'block';
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Validation Error',
                text: ' maximum number of rooms her is 4 you can add more in the next step.',
            });
        }
    });

    prevButton.addEventListener('click', function () {
        step2.style.display = 'none';
        step1.style.display = 'block';
    });

    addRoomButton.addEventListener('click', function () {
        const currentRoomCount = roomDetailsContainer.children.length;
        addRoomDetail(currentRoomCount);
    });

    function addRoomDetail(index) {
        const roomDetail = document.createElement('div');
        roomDetail.className = 'room-detail mb-3';

        const roomTitle = document.createElement('h6');
        roomTitle.textContent = `Room ${index + 1} Details`;
        roomDetail.appendChild(roomTitle);

        roomDetail.innerHTML += `
            <div class="form-group mb-3">
                <select class="form-control" name="RoomBookings[${index}].RoomType" required>
                    <option value="" disabled selected>Select Room Type</option>
                    ${roomTypes.map(type => `<option value="${type}">${type}</option>`).join('')}
                </select>
            </div>
            <div class="form-group mb-3">
                <input class="form-control" type="number" name="RoomBookings[${index}].NumberOfAdults" placeholder="Number of Adults" required />
            </div>
            <div class="form-group mb-3">
                <input class="form-control" type="number" name="RoomBookings[${index}].NumberOfChildren" placeholder="Number of Children" required />
            </div>
        `;
        roomDetailsContainer.appendChild(roomDetail);
    }

    document.querySelector(".book-btn").addEventListener('click', function () {
        bookingForm.dispatchEvent(new Event('submit'));
    });
});
